using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class PageController : MonoBehaviour {

	public int currentPage;
	public int maxPage;
	public UILabel pageDisplay;
	public List<GameObject> OrthographicPageRoot;
	public List<GameObject> ParspectivePageRoot;
	public UIButton NextButton;
	public UIButton PrevButton;

	private int previousFramePage = 1;

	public void GoToNextPage(){
		if( this.currentPage < this.OrthographicPageRoot.Count ){
			this.currentPage ++;
		}
	}
	public void GoToPreviousPage(){
		if( this.currentPage > 1){
			this.currentPage --;
		}
	}

	void Start(){
		this.currentPage = 1;
		this.maxPage = this.OrthographicPageRoot.Count;

		var l = this.OrthographicPageRoot.Where( d => d != null ).Select( c => c ).ToList();
		l.ForEach( c => c.SetActive(false) );
		this.OrthographicPageRoot[0].SetActive(true);

		l = this.ParspectivePageRoot.Where( d => d != null ).Select( c => c ).ToList();
		l.ForEach( c => c.SetActive(false) );
		this.ParspectivePageRoot[0].SetActive(true);
	}

	void Update(){
		this.UpdatePageDisplay();

		// 前回と違うページを指定してたらページ変更へ。
		if( this.previousFramePage == this.currentPage ) return;
		this.ChangePageToNewPage();
		this.previousFramePage = this.currentPage;
	}

	void UpdatePageDisplay(){
		if( this.pageDisplay == null ) return;
		this.pageDisplay.text = this.currentPage.ToString() + " / " + this.maxPage.ToString();
		this.pageDisplay.MakePixelPerfect();
	}

	void ChangePageToNewPage(){
		// UI画面を使い回しているのであればスルー。
		var previousGO = OrthographicPageRoot[ this.previousFramePage -1];
		var currentPageGo = OrthographicPageRoot[ this.currentPage -1];
		this.SamePageObjectSavive( previousGO, currentPageGo );

		// 3D空間のページを使い回しているのであればスルー。
		previousGO = ParspectivePageRoot[ this.previousFramePage -1];
		currentPageGo = ParspectivePageRoot[ this.currentPage -1];
		this.SamePageObjectSavive( previousGO, currentPageGo );

	}
	void SamePageObjectSavive( GameObject _previous, GameObject _current ){
		if( _current == null )Debug.LogError( "new page obj is null. at : " + this.currentPage.ToString() );
		if( Object.ReferenceEquals( _previous, _current ) ){

		} else {
			_previous.SetActive(false);
			_current.SetActive(true);
		}
	}


}
